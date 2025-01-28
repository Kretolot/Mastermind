import random

'''
/**
nazwa: Klasa Tablica
opis: Klasa liczb całkowitych
parametry: __tablica - tablica liczb, __rozmiar - rozmiar tablicy
zwraca: tworzy obiekt
autor: TG
*/
'''

class Tablica:
    __slots__ = ['__tablica', '__rozmiar'] # __ - tak jak private w innych __slots__ - dynamiczne przechowywanie atrybutow
    
    # konstruktor obiektu z klasu Tablica
    def __init__(self, rozmiar):
        if rozmiar <= 20:
            raise ValueError("Rozmiar nie miał byc wiekszy od 20") # przechwycenie bledu wprowadzonej wartosci ponizej 21
        self.__rozmiar = rozmiar
        self.__tablica = [ random.randint(1,1000) for _ in range(rozmiar) ]
        
    # metoda wyswietlająca indeks i element z obiektu tablicy
    def wyswietl_elementy(self):
        for index_tablicy, wartosc in enumerate(self.__tablica):
            print(f"{index_tablicy} : {wartosc}")
            
    '''
    /**
    nazwa: wyszukaj_wartosc
    opis: metoda szukania wartosci podanej przez uzytkownika w tablicy
    parametry: wartosc - szukana liczba
    zwraca: pierwszego polozenia szukanej wartosci
    autor: TG
    */
    '''
    def wyszukaj_wartosc(self, wartosc):
        for indeks, element in enumerate(self.__tablica):
            if element == wartosc:
                return indeks
        return -1
    
    # metoda szukająca liczby nieparzyste
    def wyswietl_nieparz(self):
        nieparzyste = [ wartosc for wartosc in self.__tablica if wartosc % 2 != 0]
        for element in nieparzyste:
            print(element)
        return(len(nieparzyste))
    
    # metoda obliczająca średnią liczb
    def srednia(self):
        if self.__rozmiar == 0:
            return 0
        return sum(self.__tablica) / self.__rozmiar
    
def main():
    # przykladowy rozmiar
    rozmiar = 25
    
    # tworze instancje
    tablica = Tablica(rozmiar)
    
    print("Elementy tablicy")
    tablica.wyswietl_elementy()
    
    # test metody szukającej wartości tablicy
    szukana = int(input("Podaj liczbe szukaną: "))
    indeks = tablica.wyszukaj_wartosc(szukana)
    if indeks != -1:
        print(f"Szukana wartosc znajduje sie pod indeksem {indeks}")
    else:
        print("Nie znaleziono szukanej wartosci")

    # test wypisywania liczb nieparzystych tablicy
    print("liczby nieparzyste w tablicy")
    ilosc_nieparzystych = tablica.wyswietl_nieparz()
    print(f"Ilosc nieparzystych {ilosc_nieparzystych}")
    
    # test obliczania średniej liczb w tablicy
    print(f"Średnia arytmetyczna liczb w tablicy: {tablica.srednia():.2f}")

if __name__ == '__main__':
    main()