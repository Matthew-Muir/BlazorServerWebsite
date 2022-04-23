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

function func04() {
    let dog = {
        "Name": "Lola",
        "Age": 12
    }

    alert("Received nothing...\nReturning JSON Obj with 2 Props...\nA Str & A Int");
    return dog;
}
