
$(window).keydown(function (event) {
    if (event.keyCode == 13)
    {
        event.preventDefault();
        addKey();
        return false;
    }
});

$('#addKey').click(function (e) {
    addKey();
});


function addKey() {
    let key = $('#keysInput').val()
    if (key != '')
    {
        let tag = document.createElement('span')
        $(tag).append(key)
        $(tag).attr('onclick', `$(this).remove();removeKey("${key}");`)
        $('.addedKeysHolder').append(tag)
        $('#keysInput').val('')
        resetKey()
    }
}

function removeKey() {
    resetKey()
}

//Reset all keys
function resetKey() {
    $('#tag-holder').val('')
    for (let i = 1; i <= $('.addedKeysHolder span').length; i++)
    {
        let theKey = $(`.addedKeysHolder span:nth-child(${i})`).text()
        //console.log(theKey)
        let prevVal = $('#tag-holder').val() + ','
        $('#tag-holder').val(prevVal + theKey)
    }
    var $j_object = $('.scope-toggler.btn-primary')
    $j_object.each(function () {
        let key = $(this).val();
        //console.log(key);
        let prevVal = $('#tag-holder').val() + ','
        $('#tag-holder').val(prevVal + key)

    });
    $('#keysInput').focus();
}


$(".scope-toggler").click(function () {
    manageScopeTogglerkeys($(this));

});

function manageScopeTogglerkeys(obj) {
    let key = obj.val();
    obj.toggleClass("btn-outline-primary");
    obj.toggleClass("btn-primary");
    if (~$('#tag-holder').val().indexOf(key)) {
        //console.log(',' + key)
        let newVal = $('#tag-holder').val().replace(',' + key, "");
        //console.log(newVal);
        $('#tag-holder').val(newVal)
    }
    else {
        let prevVal = $('#tag-holder').val() + ','
        $('#tag-holder').val(prevVal + key)
    }

}

function ShowPanel() {
    var validator = $("form").validate();
    if (validator.numberOfInvalids() > 0) {
        validator.showErrors();
        var index = $(".input-validation-error")
            .closest(".collapse")
            .index(".collapse");

        $(".card").eq(index + 1).children(".collapse").show()
    }
}

$("#save").click(function () { if (!$("form").valid()) { ShowPanel(); } });

$.validator.setDefaults({
    ignore: ""
});
