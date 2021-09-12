function display() {
    var e = "Netherlands";
    var country_input = e;
    var how = buildIbans(country_input);
    document.getElementById("demo").innerHTML = how;
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function updateUrl(url_extension){
    window.history.pushState('page2', 'Title', '/'+url_extension);
}



