# Fruit Luck API

- [Fruit Luck API](#buber-FruitLuck-api)
  - [Create FruitLuck](#create-FruitLuck)
    - [Create FruitLuck Request](#create-FruitLuck-request)
    - [Create FruitLuck Response](#create-FruitLuck-response)
  - [Get FruitLuck](#get-FruitLuck)
    - [Get FruitLuck Request](#get-FruitLuck-request)
    - [Get FruitLuck Response](#get-FruitLuck-response)
  - [Update FruitLuck](#update-FruitLuck)
    - [Update FruitLuck Request](#update-FruitLuck-request)
    - [Update FruitLuck Response](#update-FruitLuck-response)
  - [Delete FruitLuck](#delete-FruitLuck)
    - [Delete FruitLuck Request](#delete-FruitLuck-request)
    - [Delete FruitLuck Response](#delete-FruitLuck-response)

## Create FruitLuck

### Create FruitLuck Request

```js
POST / fruitLucks;
```

```json
{
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a Fun FruitLuck..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "Fruits": ["Rambutan", "Passion Fruit", "Strawberry Tree Fruit"]
}
```

### Create FruitLuck Response

```js
201 Created
```

```yml
Location: {{host}}/fruitLucks/{{id}}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a Fun FruitLuck..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2022-04-06T12:00:00",
  "Fruits": ["Cherimoya", "Thai Bananas"]
}
```

## Get FruitLuck

### Get FruitLuck Request

```js
GET /fruitLucks/{{id}}
```

### Get FruitLuck Response

```js
200 Ok
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a Fun FruitLuck..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2022-04-06T12:00:00",
  "Fruits": ["Avocado", "Lychee"]
}
```

## Update FruitLuck

### Update FruitLuck Request

```js
PUT /fruitLucks/{{id}}
```

```json
{
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy FruitLuck..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "Fruits": ["Mango", "Achacha", "mangosteen"]
}
```

### Update FruitLuck Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/fruitLucks/{{id}}
```

## Delete FruitLuck

### Delete FruitLuck Request

```js
DELETE /fruitLucks/{{id}}
```

### Delete FruitLuck Response

```js
204 No Content
```
