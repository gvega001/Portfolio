// create object User

class User{
    constructor(firstName, lastName, email, address, phone) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.address = address;
        this.phone = phone;
    }
    get firstName(){
        return this.firstName;
    }
    get lastName(){
        return this.lastName;
    }
    get email(){
        return this.email;
    }
    get address(){
        return this.address;
    }
    get phone(){
        return this.phone;
    }
}
class Employee  extends User {
    constructor(firstName,lastName,email, address, phone) {
        super(User);
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.email = email;
        this.phone = phone;
    }
    get firstName(){
        return this.firstName;
    }

}
