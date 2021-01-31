function ATM(number){
    let accountNumber = number;
    let balance = 0;
    return {
        deposit: function (amount){
           if (amount>0){
               balance += amount;
               return "your deposit of "+ amount + " was successful";
           } else {
               return "Deposit amount must be greater than 0";
           }
        },
        withdrawl: function (amount){
            if(amount> 0){
                if((balance - amount< 0)){
                    return "You have insufficient funds for this withdrawl";
                }else{
                    balance -=amount;
                    return "Please take your cash of "+ amount;
                }
            }else {
                return "Withdrawl amount must be greater than 0";
            }
        },
        getBalance: function (){
            return "The balance in your account is " + balance;
        },
        getAccount: function (){
            return "Your account number is " +accountNumber;
        }
    }
}
let banking = ATM("12345");
console.log(banking.deposit(10000));
console.log(banking.withdrawl(60));
console.log(banking.getBalance());
console.log(banking.getAccount());
