import app from "./app";
const PORT = Number.parseInt(process.env.PORT) || 5000;

app.listen(PORT, '0.0.0.0', () => {
    console.log(`API REST corriendo en puerto ${PORT}`);
    console.log("============================================>");
})