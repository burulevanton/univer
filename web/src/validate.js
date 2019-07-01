export function nameValidate(name) {
    return name.length > 0;
}

export function emailValidate(email) {
    return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email);
}

export function phoneValidate(phone) {
    return /^((\+7|8)[ \-]?){1}((\(\d{3}\))|(\d{3})){1}([ \-])?(\d{3}[\- ]?\d{2}[\- ]?\d{2})$/.test(phone);
}

export function passwordValidate(password) {
    return (password.length >= 8 && password.length <= 16);
}