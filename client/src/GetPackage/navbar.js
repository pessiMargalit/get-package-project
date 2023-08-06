import '../GetPackage/Navbar.css'
import { useNavigate } from 'react-router-dom';
export function Navbar() {
    const navigate = useNavigate();
    return (
        <>
            <nav class="navbar">
                <div class="logo" >GetPackage</div>
                <div class="nav-links">
                    <ul class="nav-menu">
                        <li class="active"><a id='home' onClick={(e) => { navigate(`/`) }}>Home</a></li>
                        <li><a id='about' onClick={(e) => { navigate(`/about`) }} >About Us</a></li>
                        <li><a id='driver' onClick={(e) => { navigate(`/sighn-in`, { state: { user: "Driver" } }) }} >Driver</a></li>
                        <li><a id='client' onClick={(e) => { navigate(`/sighn-in`, { state: { user: "Client" } } )}} >Client</a></li>

                    </ul>
                </div>
                <i class='bx bx-grid-alt menu-hamburger'></i>
            </nav>

        </>)
}