$(() => {
    let num = 0;
    $("#add").on('click', function () {
        console.log('foo');
        num++
        $("#inputs").append(`<li><input type="text" placeholder="First Name" name="people[${num}].firstname" />
                <input type="text" placeholder="Last Name" name="people[${num}].lastname" />
                <input type="text" placeholder="Age" name="people[${num}].age" /></li>`)
    });
});