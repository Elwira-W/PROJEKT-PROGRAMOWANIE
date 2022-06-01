# PROJEKT-PROGRAMOWANIE

Program stworzony na projekt zaliczeniowy z programowania.

Pozwala on na wyliczenie czterech wskaźników: BMI (Body Mass Index), WHR (Waist-Hip Ratio), zapotrzebowania kalorycznego i wagi idealnej.

Składa się z 3 okien: okna logowania, okna głównego i okna historii, między którymi użytkownik przemieszcza się wciskając odpowiednie przyciski.

W oknie logowania użytkownik może zarejestrować się, wpisując login i hasło. Po poprawnej rejestracji tworzony jest plik tekstowy o nazwie takiej jak podany login - "login.txt", zawierający podane hasło. Wykorzystywany jest on do sprawdzania poprawności hasła przy logowaniu.

W oknie głównym użytkownik podaje następujące dane: wzrost, wagę, obwód w talii, obwód w biodrach, wiek, płeć, aktywność fizyczną oraz cel spośród trzech: odchudzanie, utrzymanie wagi, przybranie na wadze. Po kliknięciu przycisku "Policz" wyniki wypisywane są w listboxie. Użytkownik może zdecydować, żeby wyniki zostały zapisane do pliku tekstowego, klikając przycisk "Zapisz do pliku .txt". Jeżeli taki plik jeszcze nie istnieje, tworzy się plik tekstowy "loginDane.txt" i zapisywane są w nim dane. Użytkownik może także wyczyścić dane i wpisywać od nowa, wylogować się, lub sprawdzić historię, klikając przycisk "Historia".

Otwiera się wtedy okno historii, gdzie przy użyciu kalendarza użytkownik może wybrać datę (lub zakres dat). Wyniki z historii odczytywane są z pliku "loginDane.txt" i wyświetlane są w listboxie. Po kliknięciu przycisku "Powrót", okno historii zamyka się i użytkownik powraca do okna głównego.
