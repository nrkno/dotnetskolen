Under vises et eksempel på et innslag i EPG-en i følge domenemodellen vår:

```json
{
  "id": "abcd12345678",
  "tittel": "Eksempelprogram",
  "kanal": "NRK1",
  "startTidspunkt": "2021-01-01T13:00:00+00:00",
  "sluttTidspunkt": "2021-01-01T14:00:00+00:00"
}
```

Videre modellerer vi EPG-en vår til å være en liste av innslag slik de er definert over:

```json
[
  {
    "id": "abcd12345678",
    "tittel": "Eksempelprogram",
    "kanal": "NRK1",
    "startTidspunkt": "2021-01-01T13:00:00+00:00",
    "sluttTidspunkt": "2021-01-01T14:00:00+00:00"
  },
  {
    "id": "dcba87654321",
    "tittel": "Eksempelprogram 2",
    "kanal": "NRK2",
    "startTidspunkt": "2021-01-01T20:00:00+00:00",
    "sluttTidspunkt": "2021-01-01T20:30:00+00:00"
  }
]
```

#### JSON Schema

For å definere domenemodellen vår mer formelt slik at vi kan dele den med andre bruker vi JSON Schema ([https://json-schema.org/](https://json-schema.org/)):

```json

{
    "$schema": "https://json-schema.org/draft-07/schema",
    "$id": "https://github.com/nrkno/dotnetskolen/blob/steg-5/docs/epg-schema.json",
    "type": "array",
    "title": "EPG",
    "description": "JSON Schema for EPG i Dotnetskolen",
    "default": [],
    "examples": [
        [
            {
                "id": "abcd12345678",
                "tittel": "Eksempelprogram",
                "kanal": "NRK1",
                "startTidspunkt": "2021-01-01T13:00:00+00:00",
                "sluttTidspunkt": "2021-01-01T14:00:00+00:00"
            }
        ]
    ],
    "additionalItems": true,
    "items": {
        "$id": "#/items",
        "anyOf": [
            {
                "$id": "#/items/anyOf/0",
                "type": "object",
                "title": "Program",
                "description": "JSON Schema for en sending i en EPG",
                "default": {},
                "examples": [
                    {
                        "id": "abcd12345678",
                        "tittel": "Eksempelprogram",
                        "kanal": "NRK1",
                        "startTidspunkt": "2021-01-01T13:00:00+00:00",
                        "sluttTidspunkt": "2021-01-01T14:00:00+00:00"
                    }
                ],
                "required": [
                    "id",
                    "tittel",
                    "kanal",
                    "startTidspunkt",
                    "sluttTidspunkt"
                ],
                "properties": {
                    "id": {
                        "$id": "#/properties/id",
                        "default": "",
                        "description": "ID for programmet.",
                        "examples": [
                            "ABCD12345678"
                        ],
                        "title": "id",
                        "pattern": "[a-zA-Z]{4}[0-9]{8}",
                        "type": "string"
                    },
                    "tittel": {
                        "$id": "#/properties/tittel",
                        "default": "",
                        "description": "Programtittel.",
                        "examples": [
                            "Eksempelprogram"
                        ],
                        "minLength": 5,
                        "title": "Programtittel",
                        "maxLength": 100,
                        "type": "string"
                    },
                    "kanal": {
                        "$id": "#/properties/kanal",
                        "default": "",
                        "description": "Kanalen sendingen går på.",
                        "examples": [
                            "NRK1"
                        ],
                        "title": "Kanal",
                        "enum": [
                            "NRK1",
                            "NRK2",
                            "NRK3",
                            "NRKSUPER"
                        ],
                        "type": "string"
                    },
                    "startTidspunkt": {
                        "$id": "#/properties/startTidspunkt",
                        "type": "string",
                        "title": "Starttidspunkt",
                        "description": "Starttidspunktet for sendingen.",
                        "default": "",
                        "examples": [
                            "2021-01-01T13:00:00+00:00"
                        ]
                    },
                    "sluttTidspunkt": {
                        "$id": "#/properties/sluttTidspunkt",
                        "type": "string",
                        "title": "The sluttTidspunkt schema",
                        "description": "Sluttidspunktet for sendingen.",
                        "default": "",
                        "examples": [
                            "2021-01-01T14:00:00+00:00"
                        ]
                    }
                },
                "additionalProperties": true
            }
        ]
    }
}

```

JSON Schema-et over er tilgjengelig som `epg-schema.json` i mappen `docs` på branchen `steg-5`  ([https://github.com/nrkno/dotnetskolen/blob/steg-5/docs/epg-schema.json](https://github.com/nrkno/dotnetskolen/blob/steg-5/docs/epg-schema.json)).

> JSON Schema-et over er laget med [https://jsonschema.net](https://jsonschema.net)