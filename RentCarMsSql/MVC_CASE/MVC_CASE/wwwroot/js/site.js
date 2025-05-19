document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.kirala-btn').forEach(function (btn) {
        btn.addEventListener('click', function (e) {
            e.preventDefault();
            const carId = this.getAttribute('data-id');

            fetch('/Car/Kirala', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
                },
                body: JSON.stringify({ carId: carId })
            })
                .then(response => {
                    if (response.ok) {
                        alert('Sepete eklendi!');
                    } else {
                        alert('Bir hata oluştu.');
                    }
                });
        });
    });
});
