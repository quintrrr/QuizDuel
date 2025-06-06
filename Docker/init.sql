--
-- PostgreSQL database dump
--

-- Dumped from database version 16.8 (Ubuntu 16.8-0ubuntu0.24.04.1)
-- Dumped by pg_dump version 16.6 (Homebrew)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO admin;

--
-- Name: games; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.games (
    id uuid NOT NULL,
    "player1Id" uuid NOT NULL,
    "player2Id" uuid NOT NULL,
    "currentRound" integer NOT NULL,
    turn integer NOT NULL,
    "createdAt" timestamp with time zone NOT NULL,
    "finishedAt" timestamp with time zone
);


ALTER TABLE public.games OWNER TO admin;

--
-- Name: playerAnswers; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."playerAnswers" (
    id uuid NOT NULL,
    "roundId" uuid NOT NULL,
    "userId" uuid NOT NULL,
    "questionId" uuid NOT NULL,
    selected integer NOT NULL,
    "isCorrect" boolean NOT NULL
);


ALTER TABLE public."playerAnswers" OWNER TO admin;

--
-- Name: roundQuestions; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public."roundQuestions" (
    id uuid NOT NULL,
    "roundId" uuid NOT NULL,
    "questionIndex" integer NOT NULL,
    "questionId" uuid NOT NULL
);


ALTER TABLE public."roundQuestions" OWNER TO admin;

--
-- Name: rounds; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.rounds (
    id uuid NOT NULL,
    "gameId" uuid NOT NULL,
    index integer NOT NULL,
    "categoryId" uuid NOT NULL
);


ALTER TABLE public.rounds OWNER TO admin;

--
-- Name: users; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.users (
    id uuid NOT NULL,
    username character varying(50) NOT NULL,
    "passwordHash" character varying(255) NOT NULL,
    salt character varying(255) NOT NULL,
    picture character varying(255) DEFAULT ''::character varying NOT NULL,
    birthdate timestamp with time zone
);


ALTER TABLE public.users OWNER TO admin;

--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: games PK_games; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.games
    ADD CONSTRAINT "PK_games" PRIMARY KEY (id);


--
-- Name: playerAnswers PK_playerAnswers; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."playerAnswers"
    ADD CONSTRAINT "PK_playerAnswers" PRIMARY KEY (id);


--
-- Name: roundQuestions PK_roundQuestions; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."roundQuestions"
    ADD CONSTRAINT "PK_roundQuestions" PRIMARY KEY (id);


--
-- Name: rounds PK_rounds; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.rounds
    ADD CONSTRAINT "PK_rounds" PRIMARY KEY (id);


--
-- Name: users PK_users; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT "PK_users" PRIMARY KEY (id);


--
-- Name: IX_playerAnswers_roundId; Type: INDEX; Schema: public; Owner: admin
--

CREATE INDEX "IX_playerAnswers_roundId" ON public."playerAnswers" USING btree ("roundId");


--
-- Name: IX_roundQuestions_roundId; Type: INDEX; Schema: public; Owner: admin
--

CREATE INDEX "IX_roundQuestions_roundId" ON public."roundQuestions" USING btree ("roundId");


--
-- Name: IX_rounds_gameId; Type: INDEX; Schema: public; Owner: admin
--

CREATE INDEX "IX_rounds_gameId" ON public.rounds USING btree ("gameId");


--
-- Name: playerAnswers FK_playerAnswers_rounds_roundId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."playerAnswers"
    ADD CONSTRAINT "FK_playerAnswers_rounds_roundId" FOREIGN KEY ("roundId") REFERENCES public.rounds(id) ON DELETE CASCADE;


--
-- Name: roundQuestions FK_roundQuestions_rounds_roundId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public."roundQuestions"
    ADD CONSTRAINT "FK_roundQuestions_rounds_roundId" FOREIGN KEY ("roundId") REFERENCES public.rounds(id) ON DELETE CASCADE;


--
-- Name: rounds FK_rounds_games_gameId; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.rounds
    ADD CONSTRAINT "FK_rounds_games_gameId" FOREIGN KEY ("gameId") REFERENCES public.games(id) ON DELETE CASCADE;


--
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: pg_database_owner
--

GRANT USAGE ON SCHEMA public TO salavat;


--
-- Name: TABLE "__EFMigrationsHistory"; Type: ACL; Schema: public; Owner: admin
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public."__EFMigrationsHistory" TO salavat;


--
-- Name: TABLE games; Type: ACL; Schema: public; Owner: admin
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.games TO salavat;


--
-- Name: TABLE "playerAnswers"; Type: ACL; Schema: public; Owner: admin
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public."playerAnswers" TO salavat;


--
-- Name: TABLE "roundQuestions"; Type: ACL; Schema: public; Owner: admin
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public."roundQuestions" TO salavat;


--
-- Name: TABLE rounds; Type: ACL; Schema: public; Owner: admin
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.rounds TO salavat;


--
-- Name: TABLE users; Type: ACL; Schema: public; Owner: admin
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.users TO salavat;


--
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: public; Owner: admin
--

ALTER DEFAULT PRIVILEGES FOR ROLE admin IN SCHEMA public GRANT SELECT,INSERT,DELETE,UPDATE ON TABLES TO salavat;


--
-- PostgreSQL database dump complete
--

