window.clipboardCopy = {
    copyText: function (text) {
        navigator.clipboard.writeText(text).then(function () {
            alert("Успешно скопировано!");
        })
            .catch(function (error) {
                alert(error);
            });
    },
};