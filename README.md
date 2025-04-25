## API Dokumentation

### Uppgift
- [x]  Hämta alla personer i systemet
- [x]  Hämta alla intressen kopplade till en specifik person
- [x]  Hämta alla länkar kopplade till en specifik person
- [x]  Koppla en person till ett nytt intresse
- [x]  Lägga till nya länkar för en specifik person och ett specifikt intresse

## Dokumentering över varje funktion

### 1. Hämta alla personer
**Endpoint:** `GET /api/people`  
**Beskrivning:** Hämta alla personer i databasen  
**Exempelanrop:**  
**Exempelsvar:**  
### 2. Hämta alla intressen kopplade till en specifik person
**Endpoint:** `GET /api/people/{id}/interests`  
**Beskrivning:** Hämtar intressen som är kopplad till en persons Id  
**Exempelanrop:**  
**Exempelsvar:**  
### 3. Hämta alla länkar kopplade till en specifik person
**Endpoint:** `GET /api/people/{id}/links`  
**Beskrivning:** Hämtar länkar som är kopplad till en persons Id  
**Exempelanrop:**  
**Exempelsvar:**  
### 4. Koppla en person till ett nytt intresse
**Endpoint:** `POST /api/people/{personId}/Interests/{interestId}`  
**Beskrivning:** Lägger till ett intresse till en person genom deras båda unika Id.  
**Exempelanrop:**  
**Exempelsvar:**  
### 5. Lägga till nya länkar för en specifik person och ett specifikt intresse
**Endpoint:** `POST /api/people/{personId}/InterestId/{interestId}`  
**Beskrivning:** Anger unika Id för person och intresse samt en webbplats, genom validering kontrolleras  
**Exempelanrop:**  
**Exempelsvar:**  
