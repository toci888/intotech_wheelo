
 class PasswordStrength {

calculatePwdScore = (pwd)  => {
    var score = 0;
    if (!pwd) {
        return score;
    }
    // award every unique letter until 5 repetitions
    var letters = new Object();
    for (var i=0; i<pwd.length; i++) {
        letters[pwd[i]] = (letters[pwd[i]] || 0) + 1;
        score += 5.0 / letters[pwd[i]];
    }

    // bonus points for mixing it up
    var variations = {
        digits: /\d/.test(pwd),
        lower: /[a-z]/.test(pwd),
        upper: /[A-Z]/.test(pwd),
        nonWords: /\W/.test(pwd),
    }

    var variationCount = 0;
    for (var check in variations) {
        variationCount += (variations[check] == true) ? 1 : 0;
    }
    score += (variationCount - 1) * 5;

    return parseInt(score, 10);
}
}

var doopa = new PasswordStrength();

console.log(doopa.calculatePwdScore("julia"));
console.log(doopa.calculatePwdScore("GLo123Qwe"));
console.log(doopa.calculatePwdScore("B@rZap123"));
console.log(doopa.calculatePwdScore("ghostrider"));
console.log(doopa.calculatePwdScore("ghostrider123"));
console.log(doopa.calculatePwdScore("Ju1i@G10ckA!@#123"));