// Tell the computer to reserve some space in memory for a variable
var message; // Declare

// Give the variable a value
message = 5;  // Initialize

// Use the variable
console.log(message);

// Option 1
window.onload = () => {

    var input = document.getElementById("someInput");
    // var input = document.getElementById("someOtherInput");

    // console.log(input.value);
    
    console.log(input);

    var x = 9007199254740991;
    console.log(x * 2);

    showMeThis(this);

    // .00001000
    // 1/2 + 1/4 + 1/8 + 1/16 ... 1/3
}

function showMeThis(someScope) {
    console.log(someScope);
}


// Option 2
// window.onload = doSomeStuff;

function doSomeStuff() {
    var input = document.getElementById("someInput");

    console.log(input.value);
    
    console.log(input);

    fibonacci(24);
}

function fibonacci(n) {
    // 1, 1, 2, 3, 5, 8
    var a = 0;
    var b = 1;
    var addToA = true;
    //     start     loop condition    repeat after every loop
    for (var i = 1;       i < n;             i++) {
        // if i is even or odd
        if (i % 2 == 0) // even
        {
            b = a + b;
        }
        else
        {
            a = a + b;
        }
    }
    // i is a loop control variable

    // console.log(a);
    
    if (n % 2 == 0) // even
    {
        console.log(a);
    }
    else
    {
        console.log(b);
    }
}

// 1. The computer does exactly what you tell it to do

// 2. Instructions are executed in order