import NavBar from "../components/Navbar";
import designcontainer from "../assets/design-container.png";
import "./Main.css"
function TelaInicial(){
    return (
    <> 
        <NavBar />
        <main className="main-class-telainicial">
            <div className="container-img">
                <img src={designcontainer} alt="imagem" className="img-tilted" />
            </div>

            <section className="section-apresentacao">
                <h1>Transforme dedicação em destaque!</h1>
                <div className="buttons">
                    <button>Entrar</button>
                    <button>Cadastrar</button>
                </div>
            </section>
        </main>
    </>
    )
}

export default TelaInicial;