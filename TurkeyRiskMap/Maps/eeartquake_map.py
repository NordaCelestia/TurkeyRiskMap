import geopandas as gpd
import pandas as pd
import folium


gdf_turkiye = gpd.read_file("C:/Users/ipekc/OneDrive/Masaüstü/Proje shp/İl_Sınırı.shp")
gdf_turkiye = gdf_turkiye.to_crs(epsg=4326) 


dosya_yolu = 'C:/Users/ipekc/OneDrive/Masaüstü/earthquake.csv'
data_set = pd.read_csv(dosya_yolu)

data_set = gpd.GeoDataFrame(data_set, geometry=gpd.points_from_xy(data_set['long'], data_set['lat']))
data_set = data_set.set_crs(epsg=4326)

min_lat, max_lat = 36, 42
min_lon, max_lon = 26, 45
gdf_earthquake = data_set.cx[min_lon:max_lon, min_lat:max_lat]

m = folium.Map(location=[39, 35], zoom_start=6)


for index, row in gdf_earthquake.iterrows():
    folium.CircleMarker(location=[row['lat'], row['long']],
                        radius=row['richter'] / 1000,  
                        color='red',
                        fill=True,
                        fill_color='red',
                        fill_opacity=0.7,
                        popup=f"Richter: {row['richter']}").add_to(m)

m.save("earthquake_map.html")
