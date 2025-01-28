'''
aplikacja cwiczeniowa na plikach
'''

def zamiana(liczba):
    if 48 <= liczba <= 57 or 65 <= liczba <= 90 or 97 <= liczba <= 122:
        return chr(liczba)
    return None

def ascii_sprawdzaj(plik_kodow, plik_out):
    with open(plik_kodow, "rt") as plik_in, open(plik_out, "wt") as out_plik:
        for linia in plik_in:
            cols = linia.strip().replace("\n","").split(" - ")
            
            if len(cols) != 2:
                continue
            
            try:
                num1 = int(cols[0])
                num2 = int(cols[1])
            except ValueError:
                out_plik.write("Problematyczny wiersz")
                continue
            
            char1 = zamiana(num1)
            char2 = zamiana(num2)
            
            if char1:
                col3 = char1
            elif char2:
                col3 = char2
            else:
                col3 = '#'
                
            out_plik.write(f"{num1} - {num2} - {col3}\n")
            
def kolumna2(plik):
    liczby = []
    with open(plik, 'rt') as plik_in:
        for linia in plik_in:
            cols = linia.strip().replace("\n", "").split(" - ")
            if len(cols) >= 2:
                try:
                    liczby.append(int(cols[1]))
                except ValueError:
                    continue
    return liczby

#def bubble_sort

def main():
    plik_kodow = "kody.txt"
    plik_out = "kody_3kol.txt"
    ascii_sprawdzaj(plik_kodow, plik_out)
    plik = "kody.txt"
    kolumna2(plik)

if __name__ == "__main__":
    main()