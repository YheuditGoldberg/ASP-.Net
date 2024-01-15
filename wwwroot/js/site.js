// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

Search.onclick = () => {
    const Inputfind = word.value;
    console.log(word.value)
    let p = $.ajax({
        method: 'GET',
        url: '/Cities/Get',
        success: (data) => {
            console.log(data);

        }

    });
}

//up.onclick = () => {
//    let p = $.ajax({
//        method: 'GET',
//        url: '/Cities?search=+up',
//        success: (data) => {
//            console.log(data);

//        }

//    });
//}

//down.onclick = () => {
//    let
//    let p = $.ajax({
//        method: 'GET',
//        url: '/Cities?search=-down',
//        success: (data) => {
//            console.log(data);

//        }

//    });
//}
left.onclick = (len) => {
    console.log(len)
   /* len += 5;*/
}

