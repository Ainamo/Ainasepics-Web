const res = require('./Resources.json');
let gifs = {}
let images = {}

for (let k of Object.keys(res.gifs)) {
    gifs[k] = [];
    let urls = res.gifs[k];
    for (let url of urls)
        gifs[k].push({ url, source: null });
}

for (let k of Object.keys(res.images)) {
    images[k] = [];
    let urls = res.images[k];
    
    for (let url of urls)
        images[k].push({ url, source: null });
}

require('fs').writeFileSync('testqw.json', JSON.stringify({
    gifs,
    images
}, null, 4))