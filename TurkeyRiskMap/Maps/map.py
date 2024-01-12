import geopandas as gpd
import folium
from folium.plugins import MarkerCluster
import pandas as pd

gdf_turkiye = gpd.read_file("C:/Users/ipekc/OneDrive/Masaüstü/Proje shp/İl_Sınırı.shp")
gdf_turkiye = gdf_turkiye.to_crs(epsg=4326)  

data_sets = []
for i in range(2017, 2021):
    dosya_yolu = 'C:/Users/ipekc/OneDrive/Masaüstü/Yangın/'
    csv_path = dosya_yolu + f'modis_{i}_Turkey.csv'
    data_set = pd.read_csv(csv_path)
    data_sets.append(data_set)

for i, data_set in enumerate(data_sets):
    data_sets[i] = gpd.GeoDataFrame(data_set, geometry=gpd.points_from_xy(data_set['longitude'], data_set['latitude']))
    data_sets[i] = data_sets[i].set_crs(epsg=4326)

gdf_fire = gdf_turkiye.copy()
geometry_column_data_set = 'geometry'

for i, data_set in enumerate(data_sets):
    gdf_fire = gdf_fire.merge(data_set, how='left', left_on=geometry_column_data_set, right_on=geometry_column_data_set, suffixes=('', f'_{i+1}'))

m = folium.Map(location=[39, 35], zoom_start=6)

for i, data_set in enumerate(data_sets):
    marker_cluster = MarkerCluster().add_to(m)
    for index, row in data_set.iterrows():
        folium.Marker([row['latitude'], row['longitude']], popup=f'Yangın {i+1}').add_to(marker_cluster)

folium.GeoJson(gdf_turkiye).add_to(m)

m.save('fire_map.html')

