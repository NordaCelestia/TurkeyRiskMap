import csv
import sqlite3
import os

# Dosya yolunu belirle (raw string kullanımı)
dosya_adı = 'modis_2017_Turkey.csv'
dosya_yolu = r'C:\Users\ipekc\OneDrive\Masaüstü\Yangın csv' + os.path.sep + dosya_adı

conn = sqlite3.connect('yangin.db')
cursor = conn.cursor()

for i in range(8):
    tablo_adi = f'yangin_{i+1}'
    cursor.execute(f'''
        CREATE TABLE IF NOT EXISTS {tablo_adi} (
            id INTEGER PRIMARY KEY,
            enlem REAL,
            boylam REAL,
            parlaklık REAL,
            tarama REAL,
            iz REAL,
            acq_date REAL,
            acq_time REAL,
            satellite INTEGER,
            instrument TEXT,
            confidence TEXT
        )
    ''')

    # CSV dosyasını oku ve verileri ilgili tabloya ekle
    with open(dosya_yolu, 'r', encoding='utf-8') as file:
        csv_reader = csv.reader(file, delimiter=',')
    
        # Başlık satırını atla (eğer varsa)
        next(csv_reader)
    
        for row in csv_reader:
            cursor.execute(f'INSERT INTO {tablo_adi} (enlem, boylam, parlaklık, tarama, iz, acq_date, acq_time, satellite, instrument, confidence) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)', row[1:11])

# Veriyi sorgula (örnek olarak ilk tabloyu seç)
cursor.execute("SELECT * FROM yangin_1")
rows = cursor.fetchall()

# Sonuçları ekrana yazdır
for row in rows:
    print(row)

# Değişiklikleri kaydet ve bağlantıyı kapat
conn.commit()
conn.close()
