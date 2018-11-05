function saveClient() {

    $.ajax({
        type: "POST",
        url: '@Url.Action("saveClient", "Home")',
        contentType: "application/json; charset=utf-8",
        data: { nameClient: "testing", lastNameClient: "testing", accountNumberClient: "123", accountTypeClient: "1" },
        dataType: "json",
        success: function () { alert('Success'); },
        error: function (eror) {console.log(eror)}
    });
};
