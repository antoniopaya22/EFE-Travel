import app from "./app";
const PORT = process.env.PORT || 6000;

app.listen(PORT, () => {
    console.log(`API REST corriendo en puerto ${PORT}`);
    console.log("============================================>");
})