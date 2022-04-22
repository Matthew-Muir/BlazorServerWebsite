function func01() {
    alert('I received no args and returned nothing');
}

function func02(str) {
    alert(`I received the following... \n${str}\nAnd returned nothing`)
}

function func03() {
    alert('I got nothing\nReturning a string');
    return "string from JS func03";
}

function test(num) {
    alert(typeof num);
    alert(num.length);
    alert(Math.max(...num));
}

let x = {
    "Name": "lola",
    "State": "Obnoxios"
}

function rjson() {
    return x;
}