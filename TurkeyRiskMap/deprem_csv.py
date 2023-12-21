import csv
import sqlite3
import os
import time

max_attempts = 5
attempts = 0

while attempts < max_attempts:
    try:
        # Veritabanına bağlan
        conn = sqlite3.connect('deprem1.db', timeout=10)
        cursor = conn.cursor()

        # Dosya yolunu belirle (raw string kullanımı)
        dosya_adı = 'Turkey_earthquakes.csv'
        dosya_yolu = r'C:\Users\ipekc\OneDrive\Masaüstü' + os.path.sep + dosya_adı

        # Tablo var mı diye kontrol et
        cursor.execute('''SELECT name FROM sqlite_master WHERE type='table' AND name='deprem';''')
        tablo_var_mi = cursor.fetchone()

        # Tablo yoksa oluştur
        if not tablo_var_mi:
            cursor.execute('''
                CREATE TABLE IF NOT EXISTS deprem (
                    id INTEGER PRIMARY KEY,
                    date REAL,
                    time TEXT,
                    place TEXT,
                    lat REAL,
                    long REAL,
                    deaths INTEGER,
                    mag REAL
                )
            ''')

        # CSV dosyasını oku ve verileri veritabanına ekle
        with open(dosya_yolu, 'r', encoding='utf-8') as file:
            csv_reader = csv.reader(file, delimiter=',')

            # Başlık satırını atla (eğer varsa)
            next(csv_reader)

            for row in csv_reader:
                cursor.execute('INSERT INTO deprem (date, time, place, lat, long, deaths, mag) VALUES (?, ?, ?, ?, ?, ?, ?)', row)

        # Veriyi sorgula
        cursor.execute("SELECT * FROM deprem")
        rows = cursor.fetchall()

        # Sonuçları ekrana yazdır
        for row in rows:
            print(row)

        # Değişiklikleri kaydet ve bağlantıyı kapat
        conn.commit()
        conn.close()

        break  # Döngüden çık

    except sqlite3.OperationalError as e:
        print(f"OperationalError: {e}")
        attempts += 1
        time.sleep(1)  # Bekleme süresi
