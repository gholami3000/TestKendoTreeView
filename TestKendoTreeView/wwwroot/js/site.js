// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ShowInWindow(windowElementId, content, title, onclose) {
    var windowOptions = {
        actions: ["Minimize", "Maximize", "Close"],
        draggable: true,
        resizable: true,
        //// width: "500px",
        title: title,
        visible: false,
        modal: true,
        //close: onclose
    };

    if (typeof onclose !== 'undefined') {

        windowOptions.close = onclose
    }

    $("#" + windowElementId).kendoWindow(windowOptions);
    let kendoWindowAuto = $("#" + windowElementId).data("kendoWindow");
    kendoWindowAuto.content(content);
    kendoWindowAuto.center().open();
}

var Handler = null;
var HandlerParameters = null;
function ShowKendoConfirmWindow(message, type, handler, handlerParameters, onclose) {
    Handler = handler;
    HandlerParameters = handlerParameters;
    var windowOptions = {
        actions: ["Minimize", "Maximize", "Close"],
        draggable: true,
        resizable: true,
        width: "400px",
        title: '',
        visible: false,
        modal: true,
        //close: onclose
    };

    if (typeof onclose !== 'undefined') {
        windowOptions.close = onclose
    }
    var confirmButtonColor = '';
    let btnActionCaption = '';
    let btnActionIcon = '';

    if (type === "success") {
        confirmButtonColor = 'success';
        btnActionCaption = 'انجام عملیات';
        btnActionIcon = 'check';
    }

    else if (type === "error") {
        confirmButtonColor = 'danger';
        message = `حذف` + ` <strong>${message}</strong>` + `</br> <span> عملیات انجام گردد؟ </span>`;
        btnActionCaption = 'حذف';
        btnActionIcon = 'remove';
    }

    var content = `<div>
                  ${message}
                      <div class="row mt-4">
                         <div class="col-10">
                          <button class="btn btn-secondary" onclick="CloseWindowByID('KendoConfirmWindow');return false;"> انصراف </button>
                          <button class="btn btn-${confirmButtonColor}" onclick="RunConfirmHandler();"> <i class="fa fa-${btnActionIcon}" aria-hidden="true"></i>  ${btnActionCaption} </button>
                        </div>
                     </div>
                 </div>`;

    var windowElementId = "#KendoConfirmWindow";
    $(windowElementId).kendoWindow(windowOptions);
    let kendoWindowAuto = $(windowElementId).data("kendoWindow");
    kendoWindowAuto.content(content);
    kendoWindowAuto.center().open();
}

function RunConfirmHandler() {
    Handler.apply(this, HandlerParameters);
    CloseWindowByID('KendoConfirmWindow');
}

function CloseWindowByID(windowElementId) {

    let kendoWindowAuto = $("#" + windowElementId).data("kendoWindow");
    kendoWindowAuto.close();
    //kendoWindowAuto.destroy();
    $("#" + windowElementId).html('');
}



var mainloadingOption = {
    //image: "../../Content/Images/image/loading50.gif",
    imageAnimation: "0s fadein",
    background: "rgba(0, 0, 0, 0.5)",
    imageAutoResize: true,
    imageResizeFactor: 1.5
};

function ShowLoading() {
    $.LoadingOverlaySetup(mainloadingOption);
    $.LoadingOverlay("show");
}
function HideLoading() {
    $.LoadingOverlay("hide");
}

function ShowError(errorList, elementSelector) {
    let length = errorList.length;
    item = null;
    $(elementSelector).html('');
    $(elementSelector).removeAttr("hidden");
    $(elementSelector).show();
    for (var i = 0; i < length; i++) {
        item = errorList[i];
        $(elementSelector).append(`<p>${item.message}</p>`);
    }
}

function ShowErrorForElement(errorList, elementSelector) {
    let length = errorList.length;
    $(elementSelector).html('');


    $(".error-message").html('');

    for (var i = 0; i < length; i++) {
        item = errorList[i];
        let elementName = $('[data-error-for=' + '"' + item.key + '"' + ']');
        console.log(item.key);

        if (item.key === '') {
            $(elementSelector).removeAttr("hidden");
            $(elementSelector).show();
            $(elementSelector).append(`<p>${item.message}</p>`);
        }
        else {
            elementName.html(item.message);
        }
    }
}


function GetFormDataFileList(elmentId) {

    let formDataFileList = new FormData();
    $.each(jQuery(elmentId)[0].files, function (i, file) {
        formDataFileList.append('file-' + i, file);
    });

    return formDataFileList;
}


function ConvertSerializeArrayToFormData(arrayFormData) {
    let length = arrayFormData.length;
    let _formDataList = new FormData();
    for (var i = 0; i < length; i++) {
        let FieldName = arrayFormData[i].name;
        let FielValue = arrayFormData[i].value;

        _formDataList.append(FieldName, FielValue);

    }
    return _formDataList;
}

function CombineTwoFormData(formDataFile, formDataField) {

    for (var pair of formDataField.entries()) {
        formDataFile.append(pair[0], pair[1]);
    }

    return formDataFile;
}

function b64toBlob(b64Data, contentType = '', sliceSize = 512) {
    const byteCharacters = atob(b64Data.split(",")[1]);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        const slice = byteCharacters.slice(offset, offset + sliceSize);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }


    const blob = new Blob(byteArrays, { type: contentType });
    return blob;
}

function GetObjectURLFromBase64(b64Data, contentType = '') {
    const blob = b64toBlob(b64Data, contentType);
    const blobUrl = URL.createObjectURL(blob);
    return blobUrl;
}

function SetInputFileToImgSrc(fileElement, imageElmentId) {
    const file = fileElement.files[0];
    const url = URL.createObjectURL(file);
    document.getElementById(imageElmentId).src = url;
}



function GetBase64FromInputFile(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
}

async function getBase64ImageFromUrl(imageUrl) {
    var res = await fetch(imageUrl);
    var blob = await res.blob();

    return new Promise((resolve, reject) => {
        var reader = new FileReader();
        reader.addEventListener("load", function () {
            resolve(reader.result);
        }, false);

        reader.onerror = () => {
            return reject(this);
        };
        reader.readAsDataURL(blob);
    })
}