import csv
import sqlite3
import os
import time

max_attempts = 5
attempts = 0

while attempts < max_attempts:
    try:
        conn = sqlite3.connect('deprem1.db', timeout=10)
        cursor = conn.cursor()

        dosya_adı = 'Turkey_earthquakes.csv'
        dosya_yolu = r'C:\Users\ipekc\OneDrive\Masaüstü' + os.path.sep + dosya_adı

        cursor.execute('''SELECT name FROM sqlite_master WHERE type='table' AND name='deprem';''')
        tablo_var_mi = cursor.fetchone()

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

        with open(dosya_yolu, 'r', encoding='utf-8') as file:
            csv_reader = csv.reader(file, delimiter=',')

            next(csv_reader)

            for row in csv_reader:
                cursor.execute('INSERT INTO deprem (date, time, place, lat, long, deaths, mag) VALUES (?, ?, ?, ?, ?, ?, ?)', row)

        cursor.execute("SELECT * FROM deprem")
        rows = cursor.fetchall()

        for row in rows:
            print(row)

        conn.commit()
        conn.close()

        break 

    except sqlite3.OperationalError as e:
        print(f"OperationalError: {e}")
        attempts += 1
        time.sleep(1) 
