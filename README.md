# PROJEKT-PROGRAMOWANIE
ENG version ---------------------------------------------------------

Program created for a final project in programmin at university.

It allows you to calculate four indicators: BMI (Body Mass Index), WHR (Waist Hip Ratio), caloric demand and ideal weight.

The program consist of 3 windows: login window, main window, and history window, between which the user moves by pressing appropriate buttons.

In the login window, the user can register by entering login and password. After the registration succeeded, a text file is created with the name of the given login - "login.txt", containing the given password. It is later used to validate the password when logging in.

In the main window, the user enters the following data: height, weight, waist circumference, hip circumference, age, gender, physical activity and goal (either of: weight loss, weight maintenance, weight gain). After clicking the "Policz" button, the results are printed in the listbox on the right. The user can choose to save the results to a text file by clicking the "Zapisz do pliku .txt" button. If such file does not exist, new text file named "loginDane.txt" is created and the data is saved in it. The user can also clear all textboxes, comboboxes and listbox by clicking "Wyczyść wszystko" or only listbox with results by clicking "Wyczyść wyniki". From this window user can also log out, or check history by clicking the "Historia" button.

A history window then opens, where the user can select a date (or a date range) using the calendar. History results are read from the "loginDane.txt" file and displayed in the listbox on the go. After clicking the "Powrót" button, the history window closes and the user returns to the main window.

PL version ---------------------------------------------------------

Program stworzony na projekt zaliczeniowy z programowania.

Pozwala on na wyliczenie czterech wskaźników: BMI (Body Mass Index), WHR (Waist-Hip Ratio), zapotrzebowania kalorycznego i wagi idealnej.

Składa się z 3 okien: okna logowania, okna głównego i okna historii, między którymi użytkownik przemieszcza się wciskając odpowiednie przyciski.

W oknie logowania użytkownik może zarejestrować się, wpisując login i hasło. Po poprawnej rejestracji tworzony jest plik tekstowy o nazwie takiej jak podany login - "login.txt", zawierający podane hasło. Wykorzystywany jest on do sprawdzania poprawności hasła przy logowaniu.

W oknie głównym użytkownik podaje następujące dane: wzrost, wagę, obwód w talii, obwód w biodrach, wiek, płeć, aktywność fizyczną oraz cel spośród trzech: odchudzanie, utrzymanie wagi, przybranie na wadze. Po kliknięciu przycisku "Policz" wyniki wypisywane są w listboxie. Użytkownik może zdecydować, żeby wyniki zostały zapisane do pliku tekstowego, klikając przycisk "Zapisz do pliku .txt". Jeżeli taki plik jeszcze nie istnieje, tworzy się plik tekstowy "loginDane.txt" i zapisywane są w nim dane. Użytkownik może także wyczyścić dane i wpisywać od nowa, wylogować się, lub sprawdzić historię, klikając przycisk "Historia".

Otwiera się wtedy okno historii, gdzie przy użyciu kalendarza użytkownik może wybrać datę (lub zakres dat). Wyniki z historii odczytywane są z pliku "loginDane.txt" i wyświetlane są w listboxie. Po kliknięciu przycisku "Powrót", okno historii zamyka się i użytkownik powraca do okna głównego.
