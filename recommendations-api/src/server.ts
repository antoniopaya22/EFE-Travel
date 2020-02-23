import app from "./app";
const PORT = process.env.PORT || 8070;

app.listen(PORT, () => {
    console.log(`API REST corriendo en puerto ${PORT}`);
    console.log("============================================>");
})