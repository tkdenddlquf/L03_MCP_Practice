# 공용 작업 지침

프로젝트별 내용(환경, 패키지, 모듈·어셈블리 구성, 설계 문서 위치)은 아래 문서를 따른다.

@Docs/Project.md

## 작업 원칙

1. **근거 기반 작업**: 결과나 문제의 원인을 추측하지 않는다. 코드, 콘솔 로그, 에디터 상태, 문서로 확인한 뒤 진행하고, 보고할 때는 확인한 근거를 함께 적는다.
2. **정보 요청**: 작업에 필요한 데이터나 사양(수치, 기획 의도, 에셋 경로 등)이 없으면 임의로 정하지 말고 요청한다.

## C# 코드 규칙

1. `var`를 사용하지 않는다. 항상 명시적 타입을 쓴다.
2. LINQ(`System.Linq`, 쿼리 구문, 확장 메서드)를 사용하지 않는다. 반복문으로 작성한다.
3. 불필요한 줄바꿈을 넣지 않는다.
4. 불필요한 방어 코드(발생하지 않는 상황에 대한 null 체크, try-catch, 중복 검증)를 작성하지 않는다. 실제로 발생할 수 있는 경우에만 처리한다.
5. 인스펙터에 노출할 필드는 가능한 한 `public` 대신 `[SerializeField] private`로 선언한다.
6. 주석은 코드만으로 알기 어려운 핵심(의도, 제약)만 적는다. 변경 이력이나 코드를 그대로 풀어 쓴 설명은 적지 않는다.
7. 참조는 인스펙터 할당을 기본으로 한다. `GetComponent`, `Find` 계열은 프리팹이 씬에 있는 외부 컴포넌트를 찾아야 하는 경우처럼 인스펙터로 할당할 수 없을 때만 사용한다.
8. 입력은 반드시 Input System(`UnityEngine.InputSystem`)을 사용한다. 기존 `UnityEngine.Input` API는 사용하지 않는다.
9. 필드 이름에 `_`, `m_` 같은 접두사를 붙이지 않는다. (예: `speed`, `rigidbody`)
10. 네임스페이스는 기본적으로 작성하지 않는다. 어셈블리(`.asmdef`)를 나눈 경우에만 `<프로젝트>.<모듈>` 형식으로 작성한다.

## 모듈 구조

- 기능 단위 모듈로 개발한다. 모듈은 `#Scripts/<모듈>/` 폴더 하나에 둔다.
- 어셈블리는 컴파일 시간, 테스트, 의존 경계 강제에 이득이 있을 때만 나눈다. 나머지는 기본 어셈블리(Assembly-CSharp)에 둔다.
- 하위 모듈은 상위 모듈을 참조하지 않는다. 상위에 알릴 일은 C# 이벤트나 인터페이스로 처리한다.

## 폴더 구조

프로젝트 에셋은 `Assets/` 바로 아래에 `#` 접두사를 붙인 에셋 종류별 폴더에 둔다.

- `#Scripts`, `#Prefabs`, `#Scenes`
- 새 종류가 필요하면 같은 규칙으로 만든다. (예: `#Materials`, `#Textures`, `#Animations`)
- `#Scripts`는 모듈별 하위 폴더를 둔다. 다른 폴더의 하위 폴더는 상황을 보고 만든다.
- `#Scenes`는 하위 폴더 없이 사용한다. 모듈 테스트 씬은 `Sandbox_<모듈>.unity`로 이름 짓는다.
- 렌더 파이프라인 설정(`Settings`), `InputSystem_Actions.inputactions`처럼 Unity나 패키지가 기본 생성하는 에셋은 기본 위치에 둔다.

## 클래스 멤버 순서

1. `[SerializeField] private` 필드
2. 그 외 필드 (`protected` → `public` → `private` 순)
3. 상수(`const`), 읽기 전용(`readonly`) 필드
4. 프로퍼티
5. 생명주기 함수 (`Awake`, `OnEnable`, `Start`, `Update`, `FixedUpdate`, `LateUpdate`, `OnDisable`, `OnDestroy` 순)
6. `protected`, `public` 함수
7. `private` 함수
8. Unity 이벤트 콜백 (`OnCollisionEnter`, `OnTriggerEnter`, `OnPointerEnter` 등)

## Unity 작업 절차

- 스크립트를 생성하거나 수정한 뒤에는 `read_console`로 컴파일 에러가 없는지 확인한다.
- 씬, 프리팹, 에셋 수정은 YAML을 직접 편집하지 말고 MCP 도구로 한다.
- Unity API는 기억에 의존하지 말고 `unity_reflect`, `unity_docs`, 프로젝트 내 사용 예로 확인한다.
