# .NET Desktop Aplikacija za Vremensku Prognozu

Ova desktop aplikacija za vremensku prognozu je jednostavna aplikacija koja pruža informacije o vremenskim uslovima za određenu lokaciju. Podaci se preuzimaju sa OpenWeatherMap API-ja kako bi se prikazali trenutni vremenski uslovi, prognoza, zagađenje vazduha i UV indeks. Dodatno, reprodukuje zvučnu obaveštenje na osnovu vremenskih uslova (kiša ili sunčano).

## Funkcionalnosti
- **Trenutno Vreme**: Prikazuje trenutne vremenske uslove, temperaturu, brzinu vetra, pritisak, vreme izlaska i zalaska sunca.
- **Prognoza**: Prikažite vremensku prognozu za narednih 8 dana.
- **Zagađenje Vazduha**: Pruža informacije o zagađenju vazduha na određenoj lokaciji.
- **UV Indeks**: Prikazuje UV indeks na određenoj lokaciji.
- **Zvučno Obaveštenje**: Reprodukuje zvučno obaveštenje kada pada kiša ili je sunčano.

## Instalacija
Da biste pokrenuli ovu aplikaciju, sledite ove korake:
1. Klonirajte repozitorijum na vaš lokalni računar.
2. Otvorite rešenje u Visual Studiju.
3. Izgradite i pokrenite aplikaciju.

## Upotreba
1. Unesite ime grada u predviđeni tekstualni okvir.
2. Pritisnite taster Enter ili kliknite na dugme "Pretraži" da biste preuzeli vremenske podatke.
3. Aplikacija će prikazati trenutno vreme, prognozu, zagađenje vazduha i UV indeks.
4. Ako su vremenski uslovi kišoviti ili sunčani, reprodukovaće se zvučno obaveštenje.

## Zavisnosti
- Newtonsoft.Json: Koristi se za serijsku i deserijsku obradu JSON-a.
- NAudio: Koristi se za reprodukciju zvuka.



# .NET Weather Desktop Application 

- This Weather Desktop Application is a simple application that provides weather information for a specified location. It retrieves data from the OpenWeatherMap API to display current weather conditions, forecast, air pollution, and UV index. Additionally, it plays a sound notification based on the weather condition (rainy or sunny).

## Features
- **Current Weather**: Displays the current weather condition, temperature, wind speed, pressure, sunrise, and sunset time.
- **Forecast**: Shows the weather forecast for the next 8 days.
- **Air Pollution**: Provides information about air pollution in the specified location.
- **UV Index**: Displays the UV index at the specified location.
- **Sound Notification**: Plays a sound notification when it's raining or sunny.

## Installation
To run this application, follow these steps:
1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build and run the application.

## Usage
1. Enter the city name in the provided text box.
2. Press the Enter key or click the "Search" button to fetch weather data.
3. The application will display the current weather, forecast, air pollution, and UV index.
4. If the weather condition is rainy or sunny, a sound notification will be played.

## Dependencies
- Newtonsoft.Json: Used for JSON serialization and deserialization.
- NAudio: Used for sound playback.
