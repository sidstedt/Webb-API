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
```
curl -X 'GET' \  
'https://localhost:7119/api/People' \
-H 'accept: text/plain'
```  

**Exempelsvar:**  
```
[
  {
    "firstName": "string",
    "lastName": "string",
    "phone": "string"
  }
]
```
**Om något gått fel:**
```
{
  message = "Inga personer finns i databasen"
}
```
### 2. Hämta alla intressen kopplade till en specifik person
**Endpoint:** `GET /api/people/{id}/interests`  
**Beskrivning:** Hämtar intressen som är kopplad till en persons Id  
**Exempelanrop:** 
```
curl -X 'GET' \
  'https://localhost:7119/api/People/1/interests' \
  -H 'accept: text/plain'
```  
**Exempelsvar:** 
```
{
  "firstName": "string",
  "lastName": "string",
  "phone": "string",
  "interests": [
    {
      "name": "string",
      "description": "string"
    }
  ]
}
```
**Om något gått fel:**
```
{
  message = "Personen kunde inte hittas"
}
```
### 3. Hämta alla länkar kopplade till en specifik person
**Endpoint:** `GET /api/people/{id}/links`  
**Beskrivning:** Hämtar länkar som är kopplad till en persons Id  
**Exempelanrop:** 
```
curl -X 'GET' \
  'https://localhost:7119/api/People/1/links' \
  -H 'accept: text/plain'
```  
**Exempelsvar:** 
```
{
  "firstName": "string",
  "lastName": "string",
  "phone": "string",
  "links": [
    {
      "linkName": "string"
    }
  ]
}
```
**Om något gått fel:**
```
{
  message = "Personen kunde inte hittas"
}
```
### 4. Koppla en person till ett nytt intresse
**Endpoint:** `POST /api/people/{personId}/Interests/{interestId}`  
**Beskrivning:** Lägger till ett intresse till en person genom deras båda unika Id.  
**Exempelanrop:** 
```
curl -X 'POST' \
  'https://localhost:7119/api/People/1/Interests/3' \
  -H 'accept: */*' \
  -d ''
```
**Om något gått fel:**
```
{
  message = "Person eller intresse hittades inte."
}
``` 
### 5. Lägga till nya länkar för en specifik person och ett specifikt intresse
**Endpoint:** `POST /api/people/{personId}/InterestId/{interestId}`  
**Beskrivning:** Anger unika Id för person och intresse samt en webbplats, genom validering kontrolleras  
**Exempelanrop:**
```
curl -X 'POST' \
  'https://localhost:7119/api/People/1/InterestId/2?link=https%3A%2F%2Fwww.ea.com%2F' \
  -H 'accept: */*' \
  -d ''
```  
**Om något gått fel:**
```
{
  message = "Person eller intresse hittades inte." }
}
```
```
{
  message = "Person och intresse matchar inte."
}
```
```
{
  message = "Ogiltig URL."
}
```
