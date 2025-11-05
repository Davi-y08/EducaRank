import "./index.css"

export interface NavItemInterface{
    url: string;
    label: string;
    img: string;
}

export default function NavItem(props: NavItemInterface){
    return(
        <li className="nav-item">
            <a className="nav-link" href={props.url}>
                <img className="nav-img" src={props.img} alt="logo-navitem" />
                {props.label}</a>
        </li>
    );
}