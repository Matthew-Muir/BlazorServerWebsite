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

function func05(name, age) {
    let dog = {
        "Name": name,
        "Age": age
    }

    alert("Received 2 args...\nReturning JSON Obj with 2 Props...\nA Str & A Int");
    return dog;
}

async function setImageUsingStreaming(imageElementId, imageStream) {
    const arrayBuffer = await imageStream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    document.getElementById(imageElementId).src = url;
}
