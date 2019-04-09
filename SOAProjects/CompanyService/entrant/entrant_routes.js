module.exports = (app) => {
    const entrantes = require('./entrant_controller');//

    // Создание Абитуриента
    app.post('/Entrant', entrantes.create);

    // Найти всех абитуриентов
    app.get('/Entrant', entrantes.findAll);

    // Найти абитуриента по ID
    app.get('/Entrant/:entrantId', entrantes.findOne);

    // Обновление
    app.put('/Entrant/:entrantId', entrantes.update);

    // Удаление
    app.delete('/Entrant/:entrantId', entrantes.delete);
}