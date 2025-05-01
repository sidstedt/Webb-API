## API Dokumentation

### Uppgift
- [x]  Hämta alla personer i systemet
- [x]  Hämta alla intressen kopplade till en specifik person
- [x]  Hämta alla länkar kopplade till en specifik person
- [x]  Koppla en person till ett nytt intresse
- [x]  Lägga till nya länkar för en specifik person och ett specifikt intresse

## Dokumentering över varje funktion
<details close>
<summary>
  1. Hämta alla personer
</summary>
<br>

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

**Felmeddelande:**
```
{
  message = "Inga personer finns i databasen"
}
```
</details>
<details close>
  <summary>
    2. Hämta alla intressen kopplade till en specifik person
  </summary>

**Endpoint:** `GET /api/People/{id}/interests`  

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

**Felmeddelande:**

```
{
  message = "Personen kunde inte hittas"
}
```
</details>
<details close>
  <summary>
    3. Hämta alla länkar kopplade till en specifik person
  </summary>

**Endpoint:** `GET /api/People/{id}/links`  

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

**Felmeddelande:**
```
{
  message = "Personen kunde inte hittas"
}
```
</details>
<details close>
  <summary>
    4. Koppla en person till ett nytt intresse
  </summary>
  
**Endpoint:** `POST /api/People/{personId}/interests/{interestId}`  

**Beskrivning:** Lägger till ett intresse till en person genom deras båda unika Id.  

**Exempelanrop:** 
```
curl -X 'POST' \
  'https://localhost:7119/api/People/1/interests/3' \
  -H 'accept: */*' \
  -d ''
```

**Exempelsvar:**
```
{
  message = "Intresset har lagts till personen."
}
```

**Felmeddelande:**
```
{
  message = "Person eller intresse hittades inte."
}
```
</details>
<details close>
  <summary>
    5. Lägga till nya länkar för en specifik person och ett specifikt intresse
  </summary>
  
**Endpoint:** `POST /api/People/{personId}/interestId/{interestId}`  

**Beskrivning:** Anger unika Id för person och intresse samt en webbplats, genom validering kontrolleras  

**Exempelanrop:**
```
curl -X 'POST' \
  'https://localhost:7119/api/People/1/interestId/2?link=https%3A%2F%2Fwww.example.com%2F' \
  -H 'accept: */*' \
  -d ''
```

**Exempelsvar:**
```
{
  message = "Länken har lagts till intresset." 
}
```

**Felmeddelande:**
```
{
  message = "Person eller intresse hittades inte." 
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
</details>
