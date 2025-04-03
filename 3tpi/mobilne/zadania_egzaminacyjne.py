import random

class Tablica:
    __slots__ = ('__rozmiar', '__tablica')  # Poprawnie zdefiniowane slots
    
    def __init__(self, rozmiar):
        if rozmiar <= 20:  # Rozmiar musi być większy niż 20
            raise ValueError("Rozmiar musi być większy od 20")
        self.__rozmiar = rozmiar
        self.__tablica = [random.randint(1, 1000) for _ in range(self.__rozmiar)]  # Użycie _ zamiast i dla czytelności

    def show_tablica(self):  # Pokazuje zawartość tablicy
        for idx, val in enumerate(self.__tablica):
            print(f"{idx} : {val}")
        
    def search_element(self, ele):  # Wyszukiwanie elementu w tablicy
        for idx, val in enumerate(self.__tablica):
            if val == ele:
                return idx
        return -1

    def show_odd(self):  # Wyświetla nieparzyste elementy
        odds = [val for val in self.__tablica if val % 2 != 0]
        for odd in odds:
            print(odd)
        return len(odds)
    
    def calc_avg(self):  # Obliczanie średniej
        if not self.__tablica:  # Sprawdzanie, czy tablica nie jest pusta
            return 0
        return sum(self.__tablica) / len(self.__tablica)


def main():
    rozmiar = 21
    tab = Tablica(rozmiar)
    tab.show_tablica()

    element = int(input("Podaj szukaną wartość: "))

    indeks = tab.search_element(element)
    if indeks != -1:
        print(f"Szukana wartość pod indeksem: {indeks}")
    else:
        print("Wartość nie znaleziona.")

    ile_nieparzystych = tab.show_odd()
    print(f"Ilość nieparzystych: {ile_nieparzystych}")

    print(f"Średnia elementów: {tab.calc_avg()}")


if __name__ == "__main__":
    main()
