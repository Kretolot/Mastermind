'''
 Zadanie zaliczeniowe z Python
 Imię i nazwisko: Tomasz Gradowski
 Data: 21.01.2025
'''

def zamiana(num):
    if 48 <= num <= 57 or 65 <= num <= 90 or 97 <= num <= 122:
        return chr(num)
    return '#'

def odczyt(odczytaj, zapisz):
    kol = []
    with open(odczytaj, '+rt') as read, open(zapisz, '+wt') as save:
        for i in read:
            part = i.strip().split(' - ')
            kol1, kol2 = int(part[0]), int(part[1])
            znak1, znak2 = zamiana(kol1), zamiana(kol2)
            if znak1 != '#':
                wynik = znak1
            elif znak2 != '#':
                wynik = znak2
            else:
                wynik = '#'
            save.write(f"{kol1} - {kol2} - {wynik}\n")
            kol.append((kol1, kol2, wynik))
    return kol

def sort1(kol, kolumna):
    n = len(kol)
    for i in range(n):
        for j in range(0, n-i-1):
            if kol[j][kolumna] > kol[j+1][kolumna]:
                kol[j], kol[j+1] = kol[j+1], kol[j]
    return kol

def sort2(kol, kolumna):
    n = len(kol)
    for i in range(n):
        min_idx = i
        for j in range(i+1, n):
            if kol[j][kolumna] < kol[min_idx][kolumna]:
                min_idx = j
        kol[i], kol[min_idx] = kol[min_idx], kol[i]
    return kol

def posortowane():
    kol = odczyt('kody.txt', 'kody+ascii.txt')
    posortowane_1 = sort1(kol, 1)
    posortowane_2 = sort2(kol, 1)
    with open('posortowane_sort1.txt', '+wt') as plik1, open('posortowane_sort2.txt', '+wt') as plik2:
        for i in posortowane_1:
            plik1.write(f"{i[0]} - {i[1]} - {i[2]}\n")
        for i in posortowane_2:
            plik2.write(f"{i[0]} - {i[1]} - {i[2]}\n")

def main():
    posortowane()

if __name__ == "__main__":
    main()
