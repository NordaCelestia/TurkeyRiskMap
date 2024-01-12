import csv
import sqlite3
import os

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

    with open(dosya_yolu, 'r', encoding='utf-8') as file:
        csv_reader = csv.reader(file, delimiter=',')
    
        next(csv_reader)
    
        for row in csv_reader:
            cursor.execute(f'INSERT INTO {tablo_adi} (enlem, boylam, parlaklık, tarama, iz, acq_date, acq_time, satellite, instrument, confidence) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)', row[1:11])

cursor.execute("SELECT * FROM yangin_1")
rows = cursor.fetchall()

for row in rows:
    print(row)

conn.commit()
conn.close()
