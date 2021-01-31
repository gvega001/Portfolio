//creating an new array
let shoppingList = ['eggs', 'milk', 'bread', 'cereal', 'soda', 'apples'];

//for using a for and in to  iterate through an array.
for (let shoppingListKey in shoppingList) {
    console.log(shoppingList[shoppingListKey]);
}
// for each
shoppingList.forEach(function(items){
    console.log(items);
});

// traditional for
for (let i =0; i<=5 ; i++){
    console.log(shoppingList[i]);
}
// for using of
for(let myList of shoppingList){
    console.log(myList);
}
