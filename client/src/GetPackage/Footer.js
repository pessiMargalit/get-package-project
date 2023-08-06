import '../GetPackage/Footer.css'
import { useNavigate } from 'react-router-dom'
export function Footer() {
    const navigate = useNavigate();
    return (
        <footer>
            <div>
                <span class="logo">GetPackage</span>
            </div>

            <div class="row">
                <div class="col-3">
                    <ul class="footer-cat-links">
                        <li><a onClick={(e) => { navigate(`/`) }} ><span>Home</span></a></li>
                        <li><a onClick={(e) => { navigate(`/About`) }}><span>About us</span></a></li>
                    </ul>
                </div>
                <div class="col-3">

                    <ul class="footer-cat-links">
                        <li><a onClick={(e) => { navigate(`/Rooms`) }}><span>Driver</span></a></li>
                        <li><a onClick={(e) => { navigate(`/Resevation`) }}><span>Resevation</span></a></li>
                        <li><a onClick={(e) => { navigate(`/Location`) }}><span>Location</span></a></li>
                    </ul>
                </div>

                <div class="col-3" id="newsletter">
                    <span>Stay Connected</span>
                    <form id="subscribe">
                        <input type="email" id="subscriber-email" placeholder="Enter Email Address" />
                        <i class="bi bi-arrow-right fa-lg"></i>
                    </form>
                    <div style={{ marginLeft: "3.5vw" }}><p>
                        <input id='checkbox' type="checkbox" required style={{ float: "left" }}></input>
                        <h6 > I have read and agree with the OurHotel Privacy Policy
                            and I would like to receive emails about OurHotel Hotels brand promotions and special offers.
                            I can manage my email preferences or unsubscribe at any time from future emails.</h6></p>
                    </div>

                </div>
                <div class="col-3" id="newsletter">
                    <div id="address">
                        <span>Office Location</span>
                        <ul>
                            <li>
                                <div>Los Angeles<br />
                                    Office 9B, Sky High Tower, New A Ring Road, Los Angeles</div>
                            </li>
                            <li>
                                <i class="fas fa-gopuram"></i>
                                <div>Delhi<br />
                                    Office 150B, Behind Sana Gate Char Bhuja Tower, Station Road, Delhi</div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="social-links social-1 col-6" id='icons'>
                    <a href="">
                        <i class="bi bi-facebook fa-lg"></i>
                    </a>
                    <a href="">
                        <i class="bi bi-twitter fa-lg"></i>
                    </a>
                    <a href="">
                        <i class="bi bi-linkedin fa-lg"></i>
                    </a>
                    <a href="">
                        <i class="bi bi-instagram fa-lg"></i>
                    </a>
                    <a href="">
                        <i class="bi bi-youtube fa-lg"></i>
                    </a>

                </div>
            </div>
            <div id="copyright">
                &copy;  All Rights Reserved 2023
            </div>
            <div id="owner">
                <span>
                    Designed by Chavi&Pessi.Com
                </span>
            </div>
        </footer>
    )
}