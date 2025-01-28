#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

class Tablica {
private:
    vector<int> tablica;
    int rozmiar;

public:
    Tablica(int rozmiar) {
        if (rozmiar <= 20) {
            throw invalid_argument("Rozmiar miał byc wiekszy od 20.");
        }
        this->rozmiar = rozmiar;
        srand(time(NULL));
        for (int i = 0; i < rozmiar; i++) {
            tablica.push_back(rand() % 1000 + 1);
        }
    }

    void wyswietl_elementy() {
        for (int i = 0; i < rozmiar; i++){
            cout << i << " : " << tablica[i] << endl;
        }
    }

    int wyszukaj_element(int wartosc) {
        for (int i = 0; i < rozmiar; i++) {
            if (wartosc == tablica[i]) {
                return i;
            }
        }
        return -1;
    }
    
    int wyswietl_nieparzyste() {
        int ile = 0;
        for (int i = 0; i < rozmiar; i++) {
            if (tablica[i] % 2 != 0) {
                cout << tablica[i] << "  ";
                ile++;
            }
        }
        return ile;
    }

    double srednia() {
        if (rozmiar == 0) {
            return 0;
        }
        int suma = 0;
        for (int i = 0; i < rozmiar; i++) {
            suma += tablica[i];
        }
        return (double)suma / (double)rozmiar;
    }
};

int main()
{
    int rozmiar = 24;

    Tablica tablica(rozmiar);

    cout << "Elementy tablicy: \n";
    tablica.wyswietl_elementy();

    int szukana;
    cout << "Podaj szukana: ";
    cin >> szukana;

    int indeks = tablica.wyszukaj_element(szukana);
    if (indeks != -1) {
        cout << "znaleziona pod indeksem: " << indeks << endl;
    }
    else {
        cout << "Nie znaleziono\n";
    }

    cout << "Liczby nieparzyste: " << endl;
    int ile = tablica.wyswietl_nieparzyste();
    cout << "Ilosc liczb nieparzystych: " << ile << endl;

    cout << "srednia: " << tablica.srednia() << endl;

    return 0;
}