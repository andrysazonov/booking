import React, { useRef, useEffect, useCallback } from "react";
import styles from "./modal.module.css"




export const Modal = ({ modalIsOpen, closeModal, children, name }) => {
  let yOffset;
  let body = document.querySelector("body");
  const escFunction = useCallback((event) => {
    if (event.keyCode === 27) {
      closeModalWindow(name);
    }
  }, []);
  useEffect(() => {
    document.addEventListener("keydown", escFunction, false);
    return () => {
      document.removeEventListener("keydown", escFunction, false);
    };
  }, []);
  useEffect(() => {
    if (modalIsOpen && typeof window !== "undefined") {
      yOffset = window.pageYOffset;
 
      body.style.position = "fixed";
      if (yOffset > 0) {
        body.style.top = -${yOffset}px;
      }
    }
  }, [modalIsOpen]);

  const closeModalWindow = (event) => {
    if (typeof window !== "undefined") {
      body.style.position = "";
      body.style.top = "";
      window.scrollTo(0, yOffset);
    }
    if (modalIsOpen) {
      if (wrapperRef.current && (!wrapperRef.current.contains(event.target) || event.target.toString().includes('SVG'))) {
        closeModal(name);
      }
    } else closeModal(name);
  };

  const wrapperRef = useRef(null);

  return (
    <>
      <GlobalStyle isOpen={modalIsOpen} />

      <ModalWindow isOpen={modalIsOpen} onClick={closeModalWindow}>
        <FlexWrapperColumn>
          <ModalContent ref={wrapperRef}>
            <IconExit onClick={closeModalWindow}>
              <CloseIcon/>
            </IconExit>
            {children}
          </ModalContent>
        </FlexWrapperColumn>
      </ModalWindow>
    </>
  );
};

const GlobalStyle = createGlobalStyle`
${(props) =>
  props.isOpen &&
  css`
    body {
      overflow-y: scroll;
      width: 100%;
    }
  `}}
`;

const ModalWindow = styled.div`
  display: ${(props) => (props.isOpen ? "flex" : "none")};
  justify-content: center;
  align-items: center;
  z-index: 10;
  background-color: rgba(0, 0, 0, 0.7);
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
`;

const ModalContent = styled(Body1)`
  overflow: auto;
  background: #fff;
  padding: 72px 40px 56px 40px;

  @media screen and (min-width: 320px) {
    width: 100%;
    height: 100vh;
  }
  @media screen and (min-width: 768px) {
    height: auto;
    min-height: 40vh;
    border-radius: 16px;

    ::-webkit-scrollbar {
      width: 12px;
      border-radius: 5px;
    }
    ::-webkit-scrollbar-thumb {
      border-width: 1px 1px 1px 2px;
      border-color: #777;
      background-color: #aaa;
    }

    ::-webkit-scrollbar-thumb:hover {
      border-width: 1px 1px 1px 2px;
      border-color: #555;
      background-color: #777;
    }
    ::-webkit-scrollbar-track {
      border-width: 0;
    }
    ::-webkit-scrollbar-button:vertical:start:decrement {
    }
    ::-webkit-scrollbar-button:vertical:end:increment {
    }
    ::-webkit-scrollbar-button:horizontal:start:decrement {
    }
    ::-webkit-scrollbar-button:horizontal:end:increment {
    }
  }
`;

const FlexWrapperColumn = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;

  flex-direction: column;
  @media screen and (min-width: 320px) {
    max-width: 100%;
    min-width: 100%;
    max-height: 100vh;
  }
  @media screen and (min-width: 768px) {
    max-width: 80%;
    min-width: 50%;
    max-height: 80%;
  }
`;

const IconExit = styled.div`
  cursor: pointer;
  background-position: center center;
  background-repeat: no-repeat;
  position: relative;
  width: 32px;
  height: 32px;
  left: 99%;
  top: -50px;
`;