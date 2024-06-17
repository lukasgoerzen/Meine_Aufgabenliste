// Textarea dynamisch an Höhe anpassen
document.addEventListener('DOMContentLoaded', function () {
    var textareas = document.querySelectorAll('.description-textarea');
    textareas.forEach(function (textarea) {
        hoeheAnpassen(textarea);
    });
});

function hoeheAnpassen(textarea) {
    textarea.style.height = 'auto'; // Zurücksetzen auf automatische Höhe
    textarea.style.height = (textarea.scrollHeight) + 'px'; // Anpassen auf die Scrollhöhe des Inhalts
}

// Textarea einblenden

// Alle Buttons mit der Klasse 'show-textareas' auswählen
var buttons = document.querySelectorAll('.show-textareas');

// Schleife über alle ausgewählten Buttons
buttons.forEach(function (button) {
    // Auf Klick-Ereignis jedes Buttons hören
    button.addEventListener('click', function () {
        // Das Elternelement (td) des geklickten Buttons auswählen
        var td = this.parentElement;

        // Alle Textareas innerhalb des td-Elements auswählen
        var textareas = td.querySelectorAll('.textarea');

        // Schleife über alle ausgewählten Textareas
        textareas.forEach(function (textarea) {
            // Das 'hidden' Attribut entfernen
            if (textarea.hidden == true) {
                textarea.removeAttribute('hidden');
                hoeheAnpassen(textarea);
            }

            else {
                textarea.hidden = true;
            }
        });
    });
});





// Speicher Änderungen der Daten

fetch('/data/toDos.json')
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        console.log('Loaded data:', data);
        // Hier können Sie mit den geladenen Daten arbeiten
    })
    .catch(error => {
        console.error('Error loading data:', error);
    });


    // 
document.addEventListener('DOMContentLoaded', function () {
    var felder = document.querySelectorAll('.editable');

    felder.forEach(function (feld) {
        feld.addEventListener('change', function (event) {
            var id = feld.dataset.id;  // Annahme: Verwenden Sie ein data-Attribut für die ID
            var name = feld.name;
            var value = feld.value;

            saveChangesToServer(id, name, value);
        });
    });
});

function saveChangesToServer(id, name, value) {
    var data = {
        id: id,
        fieldName: name,
        fieldValue: value
    };

    fetch('/api/ToDo/SaveChanges', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log('Changes saved to server:', data);
        })
        .catch(error => {
            console.error('Error saving changes to server:', error);
        });
}

