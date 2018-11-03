

function generatePDF() {
    
    var doc = new jsPDF();

    var specialElementHandlers = {
        '#editor': function (element, renderer) {
            return true;
        }
    };

    doc.fromHTML($(".cke_wysiwyg_frame").contents().find("body")[0].innerHTML, 10, 10, {
        'width': 170,
        'elementHandlers': specialElementHandlers
    })
    doc.save('a4.pdf')

    console.log($(".cke_wysiwyg_frame").text());
};
