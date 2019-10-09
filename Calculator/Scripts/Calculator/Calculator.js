function Eval(op1, op2, oldOp, newOp) {
    $.ajax({
        method: "Post",
        url: "/Calculator/Evaluate",
        data:{ first: op1, second: op2, oper: oldOp },
        success: function (result) {
            $("#op1").val(result);
            $("#op2").val("");
            $("#oldOperator").val(newOp);
            $("#newOperator").val("");
            $("#result").val(result + newOp);
            getAllExpressions();
        },
        error: function (error) {
            alert(error);
        }

    })
}

$(document).ready(function () {
    $(".keypad").click(function (e) {
        var value = e.currentTarget.innerHTML;
        var oldOp = $('#oldOperator').val();
        var newOp = $('#newOperator').val();
        var op1 = $("#op1").val();
        if ($.trim(op1) == "" && (oldOp == "√" || oldOp == "%" || oldOp == "х²" || oldOp == "lx" || oldOp == "±")) {
            op1 = 1;
        }
        var op2 = $("#op2").val();
        if (value != "=") {
            var result = $("#result").val();
            result = result + value;
            var operators = ["+", "-", "×", "÷", "√", "%", "х²", "lx","±","CE"];
            if ($.inArray(value, operators) != -1) {
                
                if ($.trim(op1) == "" && (oldOp == "+" || oldOp == "-" || oldOp == "×" || oldOp == "÷")) { 
                    alert("s");
                    return false;
                }
                if ($.trim(oldOp) == "") {
                    $("#oldOperator").val(value);
                }
                else {
                    if ($.trim(newOp) == "" || newOp == undefined) {
                        if ($.trim(op2) == "") {
                            alert("s");
                            return false;
                        }
                        else {
                            $("#newOperator").val(value);
                            Eval(op1, op2, oldOp, value);
                        }
                    }
                }
            }
            else {
                if (oldOp == undefined || oldOp == "") {
                    $("#op1").val(op1 + value);
                }
                else {
                    $("#op2").val(op2 + value);
                }
            }
            $("#result").val(result);
        }
        else {
            Eval(op1, op2, oldOp, newOp);
        }
    });
});