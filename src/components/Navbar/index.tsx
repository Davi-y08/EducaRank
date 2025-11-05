import logo from "../../assets/logo.png";
import escolas from "../../assets/escolas.png";
import funcionalidades from "../../assets/funcionalidades.png";
import ranks from "../../assets/ranks.png";
import sobre from "../../assets/sobre.png";

import type { NavItemInterface } from "../Navitem";
import NavItem from "../Navitem";
import "./index.css";


export default function NavBar(){

    const items: NavItemInterface[] = [
        {
            url: "/ranks",
            label: "Ranks",
            img: ranks
        },

        {
            url: "/escolas",
            label: "Escolas",
            img: escolas
        },

        {
            url: "/funcionalidades",
            label: "Funcionalidades",
            img: funcionalidades
        },

        {
            url: "/sobre",
            label: "Sobre",
            img: sobre
        }
    ]

    return(
        <header>
            <nav className="navbar">
                <a className="logo" href="/">
                    <img src={logo} alt="EducaRank Logo" />
                    EducaRank
                </a>

                <ul className="nav-items">
                    {items.map((item, index) => (
                        <NavItem key={index} url={item.url} label={item.label}  img={item.img}/>
                    ))}
                </ul>

                <button>
                    side menu
                </button>
            </nav>
        </header>
    );
}