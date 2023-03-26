$(".Get-section").hide();

$(document).ready(function () {
  $("#post-form").validate({
    rules: {
      summ: {
        required: true,
        number: true,
        min: 1,
        max: 1000000,
      },
      mounthsnum: {
        required: true,
        number: true,
        min: 1,
        max: 120,
      },
      bet: {
        required: true,
        number: true,
        min: 1,
        max: 292,
      },
    },
    messages: {
      summ: {
        min: "Слишком маленькая сумму",
        required: "Это поле обязательно",
        max: "Слишкой большая сумма",
        step: "Больше двух знаков после запятой",
        number: "Введите корреткное число",
      },
      mounthsnum: {
        min: "Слишком маленький срок",
        required: "Это поле обязательно",
        max: "Слишком большой срок",
        step: "Больше двух знаков после запятой",
        number: "Введите корреткное число",
      },
      bet: {
        min: "Слишком маленькая ставку",
        required: "Это поле обязательно",
        max: "Слишком большая ставка",
        step: "Больше двух знаков после запятой",
        number: "Введите корреткное число",
      },
    },
    submitHandler: function (event, validator) {
      var errors = validator.errors;
      if (!errors) {
        on_click();
      }
    },
  });
});

function isSession(selector) {
  return $.ajax({
    type: "POST",
    url: "https://abdul111.bsite.net/calculate",
    data: selector,
    dataType: "json",
    async: !1,
    contentType: "application/json",
  });
}

var elements;

function on_click() {
  var selector = JSON.stringify({
    summ: $("#summ").val(),
    mounthsnum: $("#mounthsnum").val(),
    bet: $("#bet").val(),
  });

  var ajaxObj = isSession(selector);

  var ajaxResponse = ajaxObj.responseJSON.calculItems;

  console.log(ajaxResponse);

  ajaxResponse.forEach((element) => {
    let wrap = document.createElement("tr");

    let th1 = document.createElement("th");
    let th2 = document.createElement("th");
    let th3 = document.createElement("th");
    let th4 = document.createElement("th");
    let th5 = document.createElement("th");
    let th6 = document.createElement("th");

    let id = document.createTextNode(element.id);
    let data = document.createTextNode(element.datePay);
    let pay = document.createTextNode(element.pay.toFixed(2));
    let mainpay = document.createTextNode(element.mainPay.toFixed(2));
    let procentpay = document.createTextNode(element.procentPay.toFixed(2));
    let creditbalance = document.createTextNode(
      element.creditBalance.toFixed(2)
    );

    th1.append(id);
    th2.append(data);
    th3.append(pay);
    th4.append(mainpay);
    th5.append(procentpay);
    th6.append(creditbalance);

    wrap.append(th1, th2, th3, th4, th5, th6);

    $("#show_calcul").append(wrap);
  });

  $(".Get-section").show(800);
  $(".post_section").hide(800);
}

$("#back-btn").click(function () {
  $(".post_section").show(800);
  $(".Get-section").hide(800);
  $("#show_calcul").empty();
});
