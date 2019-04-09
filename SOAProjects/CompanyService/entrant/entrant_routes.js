module.exports = (app) => {
    const entrantes = require('./entrant_controller');//

    // �������� �����������
    app.post('/Entrant', entrantes.create);

    // ����� ���� ������������
    app.get('/Entrant', entrantes.findAll);

    // ����� ����������� �� ID
    app.get('/Entrant/:entrantId', entrantes.findOne);

    // ����������
    app.put('/Entrant/:entrantId', entrantes.update);

    // ��������
    app.delete('/Entrant/:entrantId', entrantes.delete);
}