import React, { useEffect, useMemo, useState } from "react";
import './index.css';
function Home() {
  return (
    <>
      <div class="jumbotron d-flex align-items-center">
        <div class="container text-center">
          <h1 class="display-1 mb-4">
            BHP
          </h1>
        </div>
        <div class="rectangle-1"></div>
        <div class="rectangle-2"></div>
        <div class="rectangle-transparent-1"></div>
        <div class="rectangle-transparent-2"></div>
        <div class="circle-1"></div>
        <div class="circle-2"></div>
        <div class="circle-3"></div>
        <div class="triangle triangle-1">
          <img src="/obj_triangle.png" alt="" />
        </div>
        <div class="triangle triangle-2">
          <img src="/obj_triangle.png" alt="" />
        </div>
        <div class="triangle triangle-3">
          <img src="/obj_triangle.png" alt="" />
        </div>
        <div class="triangle triangle-4">
          <img src="/obj_triangle.png" alt="" />
        </div>
      </div>
    </>
  );
}
export default Home