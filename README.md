# Ainasepics API
* This API gives you many random gifs/images.
* I'm not a pro at using markdown, so this might be hard to read idk

# Tutorial
## Base URL
`https://ainasepics.tk/`

## Endpoints
* There is only 1 endpoint, which works to get a single resource or multiple resources.

### /get-resource

#### Overview
* I said it at the start
###### URL
    /api/v2/get-resource
###### Paramaters
* `name`  - See [names](#names) - **(required)**
* `limit` - Limit of resources to get

 * If a limit is given, the response will contain an array of URLs
#### Examples
```
    https://ainasepics.tk/api/v2/get-resource?name=hug // No limit given 
```
###### Response
```json
{
    "url": "https://i.ibb.co/YdQPpJM/hug-q-B2t-M-min.gif",
    "source": null,
    "animated":true
}
```
 * Now, giving a limit
```
    https://ainasepics.tk/api/v2/get-resource?name=hug&limit=5 // Max limit is 5
```
###### Response
```json
[
    {
        "url": "https://i.ibb.co/C83B50T/hug-Nz9-Ve-min.gif",
        "source": null,
        "animated": true
    },
    {
        "url": "https://i.ibb.co/k9Z3gsm/hug-lrlwi-min.gif",
        "source": null,
        "animated": true
    },
    {
        "url": "https://i.ibb.co/HnJ5jYw/hug-w-DKKy-min.gif",
        "source": null,
        "animated": true
    },
    {
        "url": "https://i.ibb.co/bBbCmc9/hug-DYwpf-min.gif",
        "source": null,
        "animated": true
    },
    {
        "url": "https://i.ibb.co/qpfwXTn/hug-93bjo-min.gif",
        "source": null,
        "animated": true
    }
]
```
 * Now it is an array!

# Names
* **FOR GIFS:**

| baka  | bite     | blush   | bored    | bully  |
|-------|----------|---------|----------|--------|
| chase | cheer    | cringe  | cry      | cuddle |
| dance | facepalm | glomp   | handhold | happy  |
| hi    | highfive | hug     | kiss     | laugh  |
| lick  | love     | nervous | nom      | nope   |
| panic | pat      | poke    | pout     | punch  |
| run   | sad      | shrug   | slap     |        |

* **FOR IMAGES:**

| cat  | dog | fox |
|------|-----|-----|
| wolf |     |     |

# Hi
* I don't know what more to say, because that's it lol.