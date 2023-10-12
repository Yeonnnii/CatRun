
### 이승연

# CatRun

#### 러너 게임


https://github.com/Yeonnnii/CatRun/assets/141755349/ca1989a4-1d49-4233-aefb-684388917cb9



> 장애물을 피해 최고 점수를 획득하는 게임
> 
>  (visual studio)


---


### 개발기간
> 23.10.10 ~ 23.10.11


---


### 구현 내용


#### 필수 요구 사항

1. 인트로씬 구성
    - UI 구성
    - 시작 버튼 추가

   > ![image](https://github.com/Yeonnnii/CatRun/assets/141755349/04bd703c-f9d9-4af2-81c0-bdae9aed6200)


   > 배경 음악이 들리며, 설정으로 볼륨 조절 가능, start 누르면 main game 으로 이동
   > | Script | 기능 |
   > | :---: | :---: |
   > |https://github.com/Yeonnnii/CatRun/blob/f72555259e6f4efb938e826c7134968462667038/Assets/Scripts/UIStartSceneCanvas.cs#L19-L36|버튼 역할


#### 선택 요구 사항

##### 구현 사항
1. Instantiate 로 오브젝트 생성    >    #####마지막 오류로 미해결
   > 실행시, 장애물 반복적으로 등장
   > [no image]
   > | Script | 기능 |
   > | :---: | :---: |
   > |https://github.com/Yeonnnii/CatRun/blob/cd83d76ab72c21f888b3d7fc802b1ed1e1cd54cf/Assets/Scripts/RespawnManager.cs#L84-L90|장애물 복사

2. 스크립트로 버튼에 이벤트 추가
   > [no image]
   > | Script | 기능 |
   > | :---: | :---: |
   > |https://github.com/Yeonnnii/CatRun/blob/cd83d76ab72c21f888b3d7fc802b1ed1e1cd54cf/Assets/Scripts/GameManager.cs#L67-L76|버튼 활성화


3. delegate 사용
   > [no image]
   > | Script | 기능 |
   > | :---: | :---: |
   > |https://github.com/Yeonnnii/CatRun/blob/cd83d76ab72c21f888b3d7fc802b1ed1e1cd54cf/Assets/Scripts/RespawnManager.cs#L5-L35|장애물 지정

---
##### 그 외 선택 요구 사항

1. 오브젝트 폴링
2. InputAction 사용
3. raycast 
4. generic 을 이용한 싱글톤
5. FSM
6. Dictionary 활용
7. Queue, Stack 활용


---
#### 번외
#### 구현 하고 싶은 사항
1. end Scene
---

#ISSUE
 > GameManager로 간편히 지정하여 stage 별로 나누려고 변경하였으나, 장애물이 나타나지 않는 오류가 생김

