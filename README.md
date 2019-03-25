# ProgramDoObslugiZamowien

Jest to program stworzony w <b>Windows Form App</b>. Aplikacja przyjmuje pliki o rozszerzeniu json, xml oraz csv za pomocą przycisku, który wyświetla okno dialogowe umożliwiające wybór pliku znajdującego się na dysku użytkownika. Dodaną ścieżkę do pliku w każdej chwili można usunąć (w tym celu należy wybrać numer danej ścieżki i wcisnąć odpowiednio opisany przycisk, aby usunąć). 

Poprawny plik powinien zawierać pola określające: <br />
<b>a. ClientId – </b> znaki alfanumeryczne, bez spacji i nie dłuższe niż 6 znaków * <br />
<b>b. RequestId – </b> znaki numeryczne typu long<br />
<b>c. Name – </b> znaki alfanumeryczne z możliwymi spacjami, nie dłuższe niż 255 znaków *<br />
<b>d. Quantity – </b> znaki numeryczne typu int <br />
<b>e. Price – </b> znaki numeryczne zmiennoprzecinkowe podwójnej precyzji<br />

*Dla pliku o rozszerzeniu .csv niedozwolonym znakiem jest symbol ‘,’ (przecinek). Jest on zabroniony ze względu na to, że w owym pliku symbolem rozdzielającym kolejne dane znajdujące się w jednej linii jest właśnie znak ‘,’ (przecinek). W przypadku, gdyby dane również zawierały ‘,’ aplikacja nie byłaby w stanie poprawnie rozdzielić danych znajdujących się w jednej linii.

W razie nieprawidłowo zapisanych danych wyświetla się stosowny komunikat, a określony wpis nie jest brany pod uwagę w trakcie sporządzania raportu.
Na podstawie danych zawartych w wybranym/ch pliku/plikach sporządzany jest raport na temat wybrany przez użytkownika za pomocą elementu combobox. Raport wyświetlany jest w tabeli (element dataGridView) znajdującej się w oknie aplikacji.


 Rodzaje możliwych raportów: 
 - <b>a. Ilość zamówień - </b> suma unikalnych RequestId. Raport zwraca jeden wiersz.
 - <b>b. Ilość zamówień dla klienta o wskazanym identyfikatorze –  </b> ilość unikalnych zamówień dla klienta o identyfikatorze wpisanym przez użytkownika w odpowiednim textBoxie (aplikacja o tym informuje). Raport zwraca jeden wiersz.
  - <b> c. Łączna kwota zamówień - </b> Łączna kwota zamówień – Suma iloczynów Quantity i Price każdego wpisu
  - <b> d. Łączna kwota zamówień dla klienta o wskazanym identyfikatorze – </b> Suma iloczynów Quantity i Price wpisów przypisanych do wskazanego identyfikatora klienta (wpisanego w odpowiednią rubrykę). Raport zwraca jeden wiersz.
- <b> e. Lista wszystkich zamówień –  </b> lista wszystkich wpisów
- <b> f. Lista zamówień dla klienta o wskazanym identyfikatorze –  </b> lista wpisów przypisanych do wskazanego id klienta (id wpisane w odpowiednią rubrykę). Raport zwraca jeden lub więcej wierszy.
- <b> g. Średnia wartość zamówienia –  </b> Średnia arytmetyczna iloczynów Quantity i Price każdego zamówienia. Raport zwraca jeden wiersz
- <b> h. Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze – </b>średnia arytmetyczna iloczynów Quantity i Price zamówień przypisanych do wybranego id klienta (id wpisane w odpowiednią rubrykę)
- <b> i. Ilość zamówień pogrupowanych po nazwie – </b>lista nazw i ilości zamówień o danej nazwie  
- <b> j. Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze – </b>lista  ID wybranego klienta, nazw zamówień i ilości zamówień o danej nazwie 
- <b> k. Zamówienia w podanym przedziale cenowym – </b>Lista ID zamówień i Kwoty równej sumie iloczynów Quantity i Price ze wszystkich pozycji danego zamówienia (RequestD). Przedział cenowy jest określany przez użytkownika za pomocą wpisu wartości w odpowiednie rubryki w lewym dolnym rogu.

Wyświetlane rezultaty użytkownik może sortować klikając na nagłówek kolumny, po której ma być wykonane sortowanie.

Aplikacja nie zapisuje danych w typowiej bazie danych czy w pliku na dysku co oznacza, że po wyłączeniu aplikacji nie ma śladu po wcześniejszych ustawieniach oraz raportach.

